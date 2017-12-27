import { Component,Input, OnInit } from '@angular/core';
import {NgbDropdownConfig} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-task-actions',
  templateUrl: './task-actions.component.html',
  styleUrls: ['./task-actions.component.css'],
  providers: [NgbDropdownConfig]
})
export class TaskActionsComponent implements OnInit {
  constructor(config: NgbDropdownConfig) {
    //config.placement = 'bottom-right'
  }

  hidden: boolean = true
  menuHidden: boolean = true
  ngOnInit() {
  }

}
