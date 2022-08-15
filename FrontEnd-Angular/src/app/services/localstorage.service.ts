import { Injectable } from '@angular/core';
import { Task } from '../helpers/task';

@Injectable({
  providedIn: 'root',
})
export class LocalstorageService {
  tasks: Task[] = [];

  constructor() {}

  getTasks() {
    if (localStorage.getItem('tasks') === null) {
      this.tasks = [];
    } else {
      this.tasks = JSON.parse(localStorage.getItem('tasks')!);
    }
    return this.tasks;
  }

  addTask(task: Task) {
    //find task
    this.tasks = JSON.parse(localStorage.getItem('tasks')!);
    const found = this.tasks.findIndex(
      (element) => element.title === task.title
    );
    if (found > 0) {
      console.log(JSON.stringify(found) + 'sonuc');
      this.tasks.splice(found, 1);
      localStorage.setItem('tasks', JSON.stringify(this.tasks));
    }
    ///
    this.tasks.push(task);
    let tasks = [];
    if (localStorage.getItem('tasks') === null) {
      tasks = [];
      tasks.push(task);
      localStorage.setItem('tasks', JSON.stringify(tasks));
    } else {
      tasks = JSON.parse(localStorage.getItem('tasks')!);
      tasks.push(task);
      localStorage.setItem('tasks', JSON.stringify(tasks));
    }
  }
  deletealldata() {
    localStorage.setItem('tasks', JSON.stringify([]));
  }

  deleteTask(data: string) {
    this.tasks = JSON.parse(localStorage.getItem('tasks')!);
    const found = this.tasks.findIndex((element) => element.title === data);
    console.log(JSON.stringify(found) + 'sonuc');
    this.tasks.splice(found, 1);
    localStorage.setItem('tasks', JSON.stringify(this.tasks));
  }
}
