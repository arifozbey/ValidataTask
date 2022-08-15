import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { LocalstorageService } from 'src/app/services/localstorage.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.scss'],
})
export class TaskComponent implements OnInit {
  @Input() title!: string;
  @Input() description!: string;
  @Output() newItemEvent = new EventEmitter<string>();

  constructor(public localstorageService: LocalstorageService) {}

  ngOnInit(): void {}
  new() {
    if (this.title.length > 1) {
      if (confirm('Create a New Task?')) {
        this.title = '';
      }
    }
  }
  addTask(newTitle: any, newDescription: any) {
    this.localstorageService.addTask({
      title: newTitle.value,
      description: newDescription.value,
      hide: true,
    });
    console.log(newTitle.value, newDescription.value);

    newTitle.value = '';
    newDescription.value = '';
    this.newItemEvent.emit('reload');

    return false;
  }
}
