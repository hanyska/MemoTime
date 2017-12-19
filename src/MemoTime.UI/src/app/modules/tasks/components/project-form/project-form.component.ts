import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import {Task} from "../../../../sharded/models/Task";
import { NgForm } from '@angular/forms';
import {Project} from "../../../../sharded/models/Proj";

@Component({
  selector: 'app-project-form',
  templateUrl: './project-form.component.html',
  styleUrls: ['./project-form.component.css']
})
export class ProjectFormComponent implements OnInit{

    @Input()  name: string;
    @Output() onSubmitted = new EventEmitter<Project>();

    hidden = true

    model: Project

    submitted = false;

    constructor() { }

    onSubmit(projectForm: NgForm) {
        this.onSubmitted.emit(this.model);
        this.submitted = true;
        projectForm.resetForm()
    }

    ngOnInit(): void {
        this.model = new Project();
    }

}
