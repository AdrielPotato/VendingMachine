import { Component, OnInit } from '@angular/core';
import { SharedService } from './shared.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{

  constructor(private service: SharedService) {
    
    this.page = 1;
  }

  title = 'VendingMachine.Angular';

  Quantity = 0;
  ProductList:any=[];
  OrderList:any=[];
  TotalAmount = 0;
  Money = 0;
  Change = 0;
  page = 1;
  pageSize = 8;
  collectionSize = 0;
  Product: any;

  ngOnInit(): void {
    this.refreshProductList();
    this.refreshOrderList();
  }

  refreshProductList() {
    this.service.getProductList().subscribe(list => {
      this.ProductList = list;
    });
  }
  refreshOrderList() {
    this.service.getOrderList().subscribe((list) => {
      var currentDate = new Date();
      currentDate.setHours(0, 0, 0, 0);
      this.OrderList = list.sort((a, b) => b.id - a.id).filter(m=> new Date(m.dateCreated) >= currentDate);
      this.collectionSize = this.OrderList.length;
    });
    
  }
  chooseProductClick(item: any): void {
    this.Product = item;
    this.TotalAmount = this.Product.price;
    this.Change = this.computeChange();
  }
  insertMoneyClick(amount: number): void {
    this.Money += amount;
    this.Change = this.computeChange();
  }
  computeChange(): number {
    if (this.Money > this.TotalAmount) {
      return this.Money - this.TotalAmount;
    }
    return 0;
  }
  computeTotalMoney(money: number, amount: number): number {
    return money - amount;
  }
  buyProductClick() {
    var createOrder = {
      ProductId: this.Product.id,
      ProductName: this.Product.name,
      ProductPrice: this.Product.price
    };
    if (this.Product.qtyStock <= 0) {
      alert(this.Product.name + " is Out of Stock");
    } else if (this.TotalAmount > this.Money) {
      alert("Add more funds");
    } else {
      this.service.createOrderList(createOrder).subscribe(res => {
        this.Money = this.computeTotalMoney(this.Money, this.TotalAmount);
        this.Change = this.computeChange();
        this.refreshOrderList();
      });
      this.service.reduceProductQuantity(this.Product.id).subscribe(res => {
        this.refreshProductList();
        this.Product.qtyStock--;
      });
    }
  }
  replenishProduct(id: number) {
    this.service.refreshProductQuantity(id).subscribe(res => {
      this.refreshProductList();
    });
  }
}
