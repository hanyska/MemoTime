import { Component, OnInit, EventEmitter, Input, Output, ElementRef} from '@angular/core';
import {Task} from "../../../../sharded/models/Task";
import { NgForm } from '@angular/forms';
import {Project} from "../../../../sharded/models/Proj";
import {DateTime} from "../../../../sharded/utlity/DateTime";
import {
    NG_VALIDATORS,
    FormsModule,
    FormGroup,
    FormControl,
    ValidatorFn,
    Validators
} from '@angular/forms';

@Component({
  selector: 'app-project-form',
  templateUrl: './project-form.component.html',
  styleUrls: ['./project-form.component.css']
})
export class ProjectFormComponent implements OnInit{
    @Input() project: Project
    @Output() onAdded = new EventEmitter<Project>();
    @Output() onEdited = new EventEmitter<Project>();

    hidden = true
    mode: string
    model: Project
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
    create(projectForm: NgForm) {
        let p = new Project(null, this.model.name)
        this.onAdded.emit(this.model);

        this.submitted = true;
        projectForm.resetForm()
    }

    edit(projectForm: NgForm) {
        this.onEdited.emit(this.model)
        this.submitted = true
    }


    //--------------- INIT SECTION ---------------- //
    ngOnInit(): void {
        if (this.project == null) {
            this.initAdd()
        }else {
            this.initEdit()
        }
    }

    public initAdd(): void {
        this.mode = 'create'
        this.model = new Project(undefined, null)
    }

    public initEdit(): void {
        this.model = this.project
        this.mode = 'edit'
        this.subbmitActionName = 'Zapisz'
    }


    // @Input()  name: string;
    // @Input() project: Project
    // @Output() onSubmitted = new EventEmitter<Project>();
    //
    // hidden = true
    //
    // model: Project
    //
    // submitted = false;
    //
    // constructor() { }
    //
    // onSubmit(projectForm: NgForm) {
    //     this.onSubmitted.emit(this.model);
    //     this.submitted = true;
    //     projectForm.resetForm()
    // }
    //
    // ngOnInit(): void {
    //     this.model = new Project();
    // }

}
