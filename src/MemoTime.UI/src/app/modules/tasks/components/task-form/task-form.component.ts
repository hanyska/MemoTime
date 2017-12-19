import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import {Task} from "../../../../sharded/models/Task";
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})
export class TaskFormComponent implements OnInit{

    @Input()  name: string;
    @Output() onSubmitted = new EventEmitter<Task>();

    hidden = true

    model: Task

    submitted = false;

    constructor() { }

    onSubmit(taskForm: NgForm) {
        let t = new Task(this.model.name)
        this.onSubmitted.emit(t);
        this.submitted = true;
        taskForm.resetForm()
    }

    ngOnInit(): void {
        this.model = new Task(null)
    }
}
