import { Component, OnInit } from '@angular/core';
import {Project} from "../../../../sharded/models/Proj";
import {ProjectsService} from "../../projects.service";
import {Task} from "../../../../sharded/models/Task";
import {TasksService} from "../../tasks.service";
import { take } from 'rxjs/operators/take';

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

          this.list.tasks.push(r)
        })
  }


  onEditTaskSubmitted(task: Task): void {
    this.taskService.editTask(task)
        .subscribe(r =>
        {
        })
    }

  onEditProjectSubmitted(project: Project): void {
    this.projectService.editProject(project)
        .subscribe(r =>
        {
        })
  }

  onDeleteTaskSubmitted(task: Task): void {
    this.taskService.deleteTask(task)
        .subscribe(r => 
        {
          let index = this.list.tasks.findIndex(d => d.id == task.id)
          this.list.tasks.splice(index, 1)
        })
  }

  onDeleteProjectSubmitted(project: Project): void {
    this.projectService.deleteProject(project)
        .subscribe(r =>
        {
            let index = this.projectList.findIndex(d => d.id == project.id)
            this.projectList.splice(index, 1)
            this.ngOnInit() // ZROBIONE NA PAŁE BO NIE ODSIEZA LISTY ZADAN Z USUNEITEGO PROJEKTU
        })
  }


  onCreateProjectSubmitted(project: Project): void {
      console.log(project)
      this.projectService.createProject(project)
          .subscribe(r => {
            this.ngOnInit() // MOZE DA SIE JAKOS INACZEJ
          });
  }

  getProject(id: number): void {
    this.projectService.getProject(id)
      .subscribe(t => this.list = t)
  }

  edit(value: string) : void {
    console.log(value)
  }

  log(): void {
      console.log("dasd")
  }
}