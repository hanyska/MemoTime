import { Component, OnInit, EventEmitter, Input, Output, ElementRef, Renderer  } from '@angular/core';
import {Task} from "../../../../sharded/models/Task";
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css'],
})
export class TaskFormComponent implements OnInit{
    @Input() task: Task
    @Output() onAdded = new EventEmitter<Task>();
    @Output() onEdited = new EventEmitter<Task>();

    hidden = true
    datePickerHidden = true
    mode: string
    model: Task
    submitted = false;
    subbmitActionName = 'Dodaj'

    constructor(private elementRef: ElementRef) { }

    processForm(form: NgForm): void {
        if (this.mode == 'create') {
            this.create(form)
        } else {
            this.edit(form)
        }
    }
    create(taskForm: NgForm) {
        let t = new Task(this.model.name)
        this.onAdded.emit(t);
        this.submitted = true;
        taskForm.resetForm()
    }

    edit(taskForm: NgForm) {
        this.onEdited.emit(this.model)
        this.submitted = true
    }

    ngOnInit(): void {
        if (this.task == null) {
            this.initAdd()
        }else {
            this.initEdit()
        }
    }

    private initAdd(): void {
        this.mode = 'create'
        this.model = new Task(null)
    }

    private initEdit(): void {
        this.model = this.task
        this.mode = 'edit'
        this.subbmitActionName = 'Zapisz'
    }

    onClickedInside(event: Event): void {
        this.hidden = false;
    }

    onClickedOutside(event: Event, hidden: boolean): void {
    }
}
