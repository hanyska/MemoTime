export class Task {
  id: number
  projectId: number
  name: string
  dueDate: Date
  constructor(name: string){
    this.name = name
  }
}
