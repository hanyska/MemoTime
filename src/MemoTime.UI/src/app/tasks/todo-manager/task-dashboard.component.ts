import { Component, OnInit } from '@angular/core';
import {Project} from "../models/Proj";
import {ProjectsService} from "../services/projects.service";

@Component({
  selector: 'app-task-dashboard',
  templateUrl: './task-dashboard.component.html',
  styleUrls: ['./task-dashboard.component.css']
})
export class TodoManagerComponent implements OnInit {

  projectList : Project[]
  list: Project

  constructor(private projectService : ProjectsService) { }

  ngOnInit() {
    this.projectService.getProjects()
      .subscribe(p => this.projectList = p)

    this.projectService.getProject(11)
      .subscribe(p => this.list = p)

  }
  getProject(id: number): void {
    this.projectService.getProject(id)
      .subscribe(t => this.list = t)
    console.log(this.list)
  }
}
