import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Order} from "./order/order";
import {Meal} from "./meal/meal";
import {Portion} from "./meal/portion";


@Injectable()
export class DataService {

  constructor(private http: HttpClient) {
  }

  /* --- GET --- */
  getAllMeals(): Observable<Meal[]> {
    return this.http.get<Meal[]>('/meal/get_meals');
  }

  getMealPortions(mealId: number): Observable<Portion[]> {
    return this.http.get<Portion[]>('/meal/meal_portions/' + mealId);
  }

  getMealDetails(mealId: number): Observable<Meal> {
    return this.http.get<Meal>('/meal/meal_details/' + mealId);
  }

  getOrderDetails(orderId: number): Observable<Order> {
    return this.http.get<Order>('/order/order_details/' + orderId);
  }

  getAllPortions(): Observable<Portion[]> {
    return this.http.get<Portion[]>('/portion/get_portions');
  }

  /* --- POST --- */
  addNewOrder(order: Order): void {
    this.http.post('/order/make_order/', order);
  }

}
