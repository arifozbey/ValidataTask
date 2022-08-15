import { Component, OnInit } from '@angular/core';
import {
  DataStateChangeEvent,
  GridDataResult,
} from '@progress/kendo-angular-grid';
import { process, State } from '@progress/kendo-data-query';
import { products } from 'src/app/helpers/products';
import { Categoryy, griddata, Task } from 'src/app/helpers/task';
import { LocalstorageService } from 'src/app/services/localstorage.service';

import { ThemeService } from '../../theme/theme.service';

@Component({
  selector: 'app-kendoui',
  templateUrl: './kendoui.component.html',
  styleUrls: ['./kendoui.component.scss'],
})
export class KendouiComponent implements OnInit {
  buton = true;
  tasks!: Task[];
  listdata: any[] = [];
  title = '';
  description = '';
  public state: State = {
    filter: {
      logic: 'and',
      filters: [
        { field: 'ProductName', operator: 'contains', value: '' },
        { field: 'Category.CategoryName', operator: 'contains', value: '' },
      ],
    },
  };
  public gridData: GridDataResult = process([], this.state);

  totalcount = 0;
  constructor(
    private themeService: ThemeService,
    public localstorageService: LocalstorageService
  ) {}

  ngOnInit(): void {
    this.reload();
  }

  addTask(description: string, title: string, hide: boolean) {
    let task = new Task();
    task.description = description;
    task.title = title;
    task.hide = hide;

    this.localstorageService.addTask(task);
  }
  // deleteTask(task: Task) {
  //   if (confirm('Are you sure you want to delete this task?')) {
  //     this.localstorageService.deleteTask(task);
  //   }
  // }
  deletelocal() {
    this.localstorageService.deletealldata();
    this.gridData = process([], this.state);
    this.buton = true;
  }

  edititem(data: any) {
    this.description = data.Category.CategoryName;
    this.title = data.ProductName;
    console.log(this.description);
    console.log(this.title);
  }

  deleteitem(data: any) {
    console.log(data);
    var datareturn = this.localstorageService.deleteTask(data.ProductName);

    console.log(datareturn);
    console.log(data);

    this.reload();
  }

  reload() {
    this.tasks = this.localstorageService.getTasks();
    this.listdata = [];
    let num = 0;
    this.tasks.forEach((item) => {
      num = num + 1;
      let dada = new griddata();
      let ategoryy = new Categoryy();
      ategoryy.CategoryID = num;
      ategoryy.CategoryName = item.description!;
      ategoryy.Description = item.title!;
      dada.Category = ategoryy;

      dada.CategoryID = num;
      dada.ProductID = num;
      dada.ProductName = item.title!;
      dada.UnitPrice = 123;
      dada.FirstOrderedOn = new Date();
      dada.QuantityPerUnit = '123';
      dada.ReorderLevel = 1;
      dada.SupplierID = 1;
      dada.UnitsInStock = 123;
      dada.UnitsOnOrder = 123;
      this.listdata.push(dada);
    });

    this.gridData = process(this.listdata, this.state);
  }

  demodata() {
    this.buton = false;
    this.listdata = products;
    this.gridData = process(this.listdata, this.state);
    console.log(this.listdata);
  }

  cleargrid() {
    this.gridData = process([], this.state);
    this.buton = true;
  }

  public dataStateChange(state: DataStateChangeEvent): void {
    this.state = state;
    this.gridData = process(this.listdata, this.state);
  }

  setDarkModeTheme() {
    this.themeService.setDarkMode();
  }

  setLightModeTheme() {
    this.themeService.setLightMode();
  }

  setSystemModeTheme() {
    this.themeService.setSystemMode();
  }
}
