import {Task} from "./Task";

export class Project {
  id: number
  name: string
  tasks: Task[]

  constructor(id: number, name: string) {
    this.id = id;
    this.name = name;
  }
}
