import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})

export class SharedService {
  readonly APIUri = "https://localhost:44332/api";
  constructor(private http:HttpClient) { }

  getProductList():Observable<any> {
    return this.http.get(this.APIUri + '/Product');
  }
  reduceProductQuantity(id:number) {
    //const params = new HttpParams().append('ProductCode', code);
    return this.http.put(this.APIUri + '/Product/UpdateProduct/' + id, null);
  }
  refreshProductQuantity(id:number) {
    //const params = new HttpParams().append('ProductCode', code);
    return this.http.put(this.APIUri + '/Product/RefreshProduct/' + id, null);
  }
  getOrderList():Observable<any> {
    return this.http.get(this.APIUri + '/Order');
  }
  createOrderList(val:any) {
    return this.http.post(this.APIUri + '/Order', val);
  }
}
