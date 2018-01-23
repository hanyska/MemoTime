import {Project} from "../../../../sharded/models/Proj";
import { Component, OnInit, EventEmitter, Input, Output, ElementRef, Renderer } from '@angular/core';
import {NgbDropdownConfig} from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-project-actions',
  templateUrl: './project-actions.component.html',
  styleUrls: ['./project-actions.component.css']
})
export class ProjectActionsComponent implements OnInit {
    @Input() project: Project
    @Output() onDeleted = new EventEmitter<Project>()
    @Output() onEditClicked = new EventEmitter()

    constructor(config: NgbDropdownConfig) {

    }

    hidden: boolean = true

    delete(): void {
        this.onDeleted.emit(this.project)
    }

    edit(): void {
        this.onEditClicked.emit()
    }

    ngOnInit() {
  }

}
