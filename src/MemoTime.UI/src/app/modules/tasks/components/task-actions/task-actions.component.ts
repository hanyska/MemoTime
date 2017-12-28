import {NgbDropdownConfig} from '@ng-bootstrap/ng-bootstrap';
import {Task} from "../../../../sharded/models/Task";
import { Component, OnInit, EventEmitter, Input, Output, ElementRef, Renderer  } from '@angular/core';

@Component({
  selector: 'app-task-actions',
  templateUrl: './task-actions.component.html',
  styleUrls: ['./task-actions.component.css'],
  providers: [NgbDropdownConfig]
})
export class TaskActionsComponent implements OnInit {
  @Input() task: Task
  @Output() onDeleted = new EventEmitter<Task>()

  constructor(config: NgbDropdownConfig) {
  }

  hidden: boolean = true
  menuHidden: boolean = true
  
  ngOnInit() {
  }

  delete(): void {
    this.onDeleted.emit(this.task)
  }

}
