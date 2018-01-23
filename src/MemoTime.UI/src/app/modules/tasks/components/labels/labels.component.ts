import { Component, OnInit, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import {Task} from "../../../../sharded/models/Task";
import {Label} from "../../../../sharded/models/Label";
import {LabelsService} from "../../labels.service";

@Component({
  selector: 'app-labels',
  templateUrl: './labels.component.html',
  styleUrls: ['./labels.component.css']
})
export class LabelsComponent implements OnInit, OnChanges {
    @Input() taskName: string
    @Output() onLabelSet = new EventEmitter<Label>()

    labelsToShow= Array<Label>()
    labels = new Array<Label>()
    labelsListHidden: boolean = true
    currentLabel: Label
    isLabelSet:boolean = false

    constructor(private labelsService: LabelsService) { }



  ngOnInit() {
    this.labelsService.browseLabels()
        .subscribe(r =>
        {
          this.labels = r
            console.log(r);
        })
  }

  setLabel(label: Label): void {

    if (label.id == null) {
        this.labelsService.createLabel(label)
            .subscribe(r => {
                this.onLabelSet.emit(r)
            })
    }else {
        this.onLabelSet.emit(label);
    }

    this.isLabelSet = true;
    this.labelsListHidden = true
  }

  ngOnChanges(changes: SimpleChanges): void {
      if (this.isLabelSet) {

        this.isLabelSet = false;

        return;
      }

      if (this.taskName == null) {
          return
      }

      if (this.taskName.indexOf('#') !== -1) {
        let label = this.taskName.split('#').pop().split(' ').shift();
        this.currentLabel = new Label(label)
        this.getLabels(label)
      }
      else {
        this.labelsListHidden = true;
      }
  }

  getLabels(label: string) {
        this.labelsToShow = this.labels.filter(x => !x.name.indexOf(label))
        this.labelsListHidden = false
  }
}
