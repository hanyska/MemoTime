import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {DragulaModule} from "ng2-dragula";
import {ProjectsService} from "./projects.service";
import {TodoManagerComponent} from "./components/todo-manager/task-dashboard.component";
import { TaskFormComponent } from './components/task-form/task-form.component';

@NgModule({
  imports: [
    CommonModule,
    DragulaModule,
  ],
  exports: [
  ],
  declarations: [TodoManagerComponent, TaskFormComponent],
})
export class TasksModule { }