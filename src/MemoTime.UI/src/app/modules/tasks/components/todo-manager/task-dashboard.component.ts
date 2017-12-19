import { Component, OnInit } from '@angular/core';
import {Project} from "../../../../sharded/models/Proj";
import {ProjectsService} from "../../projects.service";
import { FormGroup } from '@angular/forms';
import {Task} from "../../../../sharded/models/Task";
import {TasksService} from "../../tasks.service";

@Component({
  selector: 'app-task-dashboard',
  templateUrl: './task-dashboard.component.html',
  styleUrls: ['./task-dashboard.component.css']
})
export class TodoManagerComponent implements OnInit {

  projectList : Project[]
  list: Project

  constructor(private projectService : ProjectsService, private taskService: TasksService) { }



  ngOnInit() {
    this.projectService.getProjects()
      .subscribe(p =>
      {
        this.projectList = p
        this.projectService.getProject(p[0].id)
            .subscribe(p => this.list = p)
      })
  }

  onCreateTaskSubmitted(task: Task, id: number): void {
    task.projectId = id
    this.taskService.createTask(task)
        .subscribe(r =>
        {
          this.list.tasks.push(task)
        })
  }

    onCreateProjectSubmitted(project: Project): void {
        this.projectService.createProject(project)
            .subscribe(r => {
              this.ngOnInit()
            });
    }

  getProject(id: number): void {
    this.projectService.getProject(id)
      .subscribe(t => this.list = t)
  }
}
