import { Component, OnInit, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import {Task} from "../../../../sharded/models/Task";

@Component({
  selector: 'app-labels',
  templateUrl: './labels.component.html',
  styleUrls: ['./labels.component.css']
})
export class LabelsComponent implements OnInit, OnChanges {

  constructor() { }
  @Input() taskName: string
  @Output() onLabelSet = new EventEmitter<string>()

  labelsToShow= Array<string>()
  labels = new Array<string>()
  labelsListHidden: boolean = true
  currentLabel: string

  ngOnInit() {
    this.labels.push('w_domu')
    this.labels.push('uczelnia')
    this.labels.push('w_pracy')
  }

  setLabel(label: string): void {
    this.labelsListHidden = true
    this.onLabelSet.emit(label)
  }

  ngOnChanges(changes: SimpleChanges): void {
      if (this.taskName.indexOf('@') !== -1) {
        let label = this.taskName.split('@').pop().split(' ').shift();
        this.currentLabel = label
        this.getLabels(label)
      } else {
        this.labelsListHidden = true
      }
  }

  getLabels(label: string) {
    this.labelsToShow = this.labels.filter(x => !x.indexOf(label))
    this.labelsListHidden = false
  }

}
