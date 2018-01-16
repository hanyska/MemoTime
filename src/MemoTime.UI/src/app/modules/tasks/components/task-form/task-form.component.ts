import { Component, OnInit, EventEmitter, Input, Output, ElementRef, Renderer  } from '@angular/core';
import {Task} from "../../../../sharded/models/Task";
import { NgForm } from '@angular/forms';
import {DateTime} from "../../../../sharded/utlity/DateTime";
import {
    NG_VALIDATORS,
    FormsModule,
    FormGroup,
    FormControl,
    ValidatorFn,
    Validators
} from '@angular/forms';

import { Directive } from '@angular/core';
@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css'],
})
export class TaskFormComponent implements OnInit{
    @Input() projectId: number
    @Input() task: Task
    @Output() onAdded = new EventEmitter<Task>();
    @Output() onEdited = new EventEmitter<Task>();
    @Output() onDoneMarked = new EventEmitter<Task>()

    hidden = true
    datePickerHidden = true
    mode: string
    model: Task
    modelConvertedDate: { year:number, month: number, day: number}
    submitted = false;
    subbmitActionName = 'Dodaj'

    constructor(private elementRef: ElementRef) { }

    processForm(form: NgForm): void { //maybe it should be removed?
        if (this.mode == 'create') {
            this.create(form)
        } else {
            this.edit(form)
        }
    }
    create(taskForm: NgForm) {
        let t = new Task(undefined, null, this.model.name, DateTime.createByNumbers(
            this.modelConvertedDate.year,
            this.modelConvertedDate.month,
            this.modelConvertedDate.day
        ))
        this.onAdded.emit(t);
        this.submitted = true;

        taskForm.resetForm()
        console.log(this.projectId)
        this.initModelConvertedDate()
    }

    edit(taskForm: NgForm) {
        this.model.dueDate = DateTime.createByNumbers(
            this.modelConvertedDate.year,
            this.modelConvertedDate.month,
            this.modelConvertedDate.day
        )
        this.onEdited.emit(this.model)
        this.submitted = true
    }

    done():void {
        this.task.done = true
        this.onDoneMarked.emit(this.model)
    }


    //--------------- INIT SECTION ---------------- //
    ngOnInit(): void {
        if (this.task == null) {
            this.initAdd()
        }else {
            this.initEdit()
        }
    }

    public initAdd(): void {
        this.mode = 'create'
        this.model = new Task(null, null, null, new Date())
        this.initModelConvertedDate()
    }

    public initEdit(): void {
        this.model = this.task
        this.model.dueDate = DateTime.creteByString(this.task.dueDate.toString())
        this.modelConvertedDate = {
            year: this.model.dueDate.getFullYear(),
            month: this.model.dueDate.getMonth()+1,
            day: this.model.dueDate.getDate()
        }
        this.mode = 'edit'
        this.subbmitActionName = 'Zapisz'
    }

    private initModelConvertedDate(): void {
        let date = new Date()
        this.modelConvertedDate = {
            year:date.getFullYear(),
            month: date.getMonth()+1,
            day: date.getDate()
        }
    }

    onLabelSet(label: string) {
        this.model.label = label
        let task_name = this.model.name.split('@').shift()
        this.model.name = ''
        this.model.name = task_name + '@' + this.model.label
    }
}

//Wuwa;o;c
function dateValidator(control: FormControl) {
        let date = new Date()
        let day = control.value as {year: number, month: number, day: number}

        if (day.day < date.getDate()) {
            return {
                dateValid: {
                    valid: false
                }
            }
        }
    return null;
}

@Directive({
    selector: '[dateValidator][ngModel]',
    providers: [
        {
            provide: NG_VALIDATORS,
            useValue: dateValidator,
            multi: true
        }
    ]
})
 export  class  DateValidator {

}
