import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {DragulaModule} from "ng2-dragula";
import {ProjectsService} from "./services/projects.service";
import {TodoManagerComponent} from "./todo-manager/task-dashboard.component";

@NgModule({
  imports: [
    CommonModule,
    DragulaModule,
  ],
  exports: [
  ],
  declarations: [TodoManagerComponent],
})
export class TasksModule { }
