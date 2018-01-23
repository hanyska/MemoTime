import {Label} from "./Label";

export class Task {
  id: number
  projectId: number
  name: string
  dueDate: Date = new Date()
  done: boolean
  label: Label
  constructor(id?: number, projectId?: number, name?: string, dueDate?: Date){
      this.id = id
      this.projectId = projectId
      this.name = name
      this.dueDate = dueDate
      this.done = false
  }
}
