import { Component, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddProductModalComponent } from './add-product-modal/add-product-modal.component';
import { ApiService } from './api.service';

import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ProductManagement';

  ELEMENT_DATA: any = [
    { position: 1, name: 'P1', category:'Electronics', subcategory:'TV, Monitor, Phone', price: 1.0079, description: 'E', quantity: 10 },
    { position: 1, name: 'P2', category:'Clothes', subcategory:'Men, Women, Children', price: 1.0079, description: 'C', quantity: 10 },
    { position: 1, name: 'P3', category:'Footwear', subcategory:'Men, Women, children', price: 1.0079, description: 'F', quantity: 10 },
  ];

  dataSource = new MatTableDataSource(this.ELEMENT_DATA);

  displayedColumns: string[] = ['position', 'name', 'category', 'subcategory'];

  constructor(private dialog: MatDialog, private api: ApiService) {

  }

  ngOnInit(): void {
    this.getAllProducts();
  }

  addProduct() {
    this.dialog.open(AddProductModalComponent, {
      height: '400px',
      width: '600px',
    });
  }

  getAllProducts() {
    this.api.getProducts()
      .subscribe({
        next: (res : any) => {
          console.log(res);
        },
        error: (err : any) => {
          console.log(err);
        }
      });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
