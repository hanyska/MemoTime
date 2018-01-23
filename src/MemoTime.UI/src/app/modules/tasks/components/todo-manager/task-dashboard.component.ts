import { Component, OnInit } from '@angular/core';
import {Project} from "../../../../sharded/models/Proj";
import {ProjectsService} from "../../projects.service";
import {Task} from "../../../../sharded/models/Task";
import {TasksService} from "../../tasks.service";
import { take } from 'rxjs/operators/take';
import {Search} from "../../../../sharded/models/Search";

@Component({
  selector: 'app-task-dashboard',
  templateUrl: './task-dashboard.component.html',
  styleUrls: ['./task-dashboard.component.css']
})
export class TodoManagerComponent implements OnInit {

  projectList : Project[]
  category: string
  list: Array<Project>
  defaultProjectId: number
  canAddTask = true

  constructor(private projectService : ProjectsService, private taskService: TasksService) { }



  ngOnInit() {
    this.projectService.getProjects()
      .subscribe(p =>
      {
        this.projectList = p
        this.defaultProjectId = p[0].id;
        this.projectService.getProject(p[0].id)
            .subscribe(p => {
                this.list = new Array<Project>()
                for(let pr of p)
                {
                   this.list.push(pr)
                }
            })
      })
  }

  onSearch(search: Search): void {
      let searchString = search.searchString;
      this.taskService.getFilteredBySearch('search', search.searchString, search.byTag)
          .subscribe(r =>
          {
              this.category = "Wyniki wyszukiwania dla: ";

              if (search.byTag) {
                  this.category+= "#";
              }

              this.category+= searchString + '...'
              this.list = r
              this.canAddTask = false
          })

  }

  onCreateTaskSubmitted(task: Task, id: number): void {
    task.projectId = id
    this.taskService.createTask(task)
        .subscribe(r =>
        {
            let proj = this.list.find(x => x.id == id)

            if (!this.list.find(x => x.id == id)) {
                proj = this.projectList.find(x => x.id == id)
                this.list.push(proj)
            }

          proj.tasks.push(r)
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
          let project = this.list.find(x => x.id == task.projectId)
          let index = project.tasks.findIndex(d => d.id == task.id)
          project.tasks.splice(index, 1)

          if (project.tasks.length < 1) {
              let projectIndex = this.list.findIndex(x => x.id == project.id)
              this.list.splice(projectIndex, 1)
          }
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

  onDoneMarked(task: Task): void {
      this.taskService.finishTask(task)
          .subscribe(r => {
              let project = this.list.find(x => x.id == task.projectId)
              let index = project.tasks.findIndex(d => d.id == task.id)
              project.tasks.splice(index, 1)

              if (project.tasks.length < 1) {
                  let projectIndex = this.list.findIndex(x => x.id == project.id)
                  this.list.splice(projectIndex, 1)
              }
          })
  }

  onCreateProjectSubmitted(project: Project): void {
      this.projectService.createProject(project)
          .subscribe(r => {
            this.ngOnInit() // MOZE DA SIE JAKOS INACZEJ
          });
  }

  getExpiredTasks(): void {
      this.taskService.getFiltered('expired')
          .subscribe(r => {
              this.category = "Zaległe"
              this.list = r
              this.canAddTask = false
          })
  }

  getFinishedTasks():void {
      this.taskService.getFiltered('finished')
          .subscribe(r => {
              this.category = "Zakończone"
              this.list = r
              this.canAddTask = false
          })

  }

  getNextSevenDays():void {
      this.taskService.getFiltered('next7days')
          .subscribe(r => {
              this.category = "Następne 7 dni"
              this.list = r
              this.canAddTask = false
          })
  }

  getToday(): void {
      this.taskService.getFiltered('today')
          .subscribe(r => {
              this.category = "Dziś"
              this.list = r
              this.canAddTask = false
          })

  }

  getProject(id: number): void {
    this.defaultProjectId = id
      console.log(id)
    this.projectService.getProject(id)
      .subscribe(t => {
          this.list = new Array<Project>()
          for(let pr of t)
          {
              this.list.push(pr)
          }
          this.canAddTask = true
          this.category = ''
      })
  }

  edit(value: string) : void {
    console.log(value)
  }

  log(): void {
      console.log("dasd")
  }
}