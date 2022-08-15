export class Task {
  title: string | undefined;
  description: string | undefined;
  hide: boolean | undefined;
}

export class Categoryy {
  CategoryID = 1;
  CategoryName = 'testc';
  Description = 'testdesc';
}

export class griddata {
  ProductID!: number;
  ProductName!: string;
  SupplierID!: number;
  CategoryID!: number;
  QuantityPerUnit!: string;
  UnitPrice!: number;
  UnitsInStock!: number;
  UnitsOnOrder!: number;
  ReorderLevel!: number;
  Discontinued!: boolean;
  Category!: Categoryy;
  FirstOrderedOn!: Date;
}
