import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Order} from "./order/order";
import {Meal} from "./meal/meal";
import {Ingredient} from "./meal/ingredient";

@Injectable()
export class DataService {

  constructor(private http: HttpClient) {
  }

  /* --- GET --- */
  showMenu(): Observable<Meal[]> {
    return this.http.get<Meal[]>('/meal/show_menu');
  }

  getMealIngredients(mealId: number): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>('/meal/meal_ingredients/' + mealId);
  }

  getAllIngredients(): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>('/ingredient/show_all_ingredients');
  }

  getOrdersHistory(): Observable<Order[]> {
    return this.http.get<Order[]>('/order/orders_history');
  }

  getOrderMeals(orderId: number): Observable<Meal[]> {
    return this.http.get<Meal[]>('/order/order_meals/' + orderId);
  }

  /* --- POST --- */
  addNewMeal(mealName: string, ingredientsToAdd: Ingredient[]) {
    let body = {
      meal: mealName,
      ingredients: ingredientsToAdd
    }
    this.http.post('/meal/new_meal', body)
      .subscribe({
        next: data => {
          console.log(data)
        },
        error: error => {
          console.error('There was an error!', error);
        }
      });
  }

  makeOrder(orderTitle: string, mealsToAdd: Meal[]) {
    let body = {
      order: orderTitle,
      meals: mealsToAdd
    }

    return this.http.post('/order/make_order', body)
      .subscribe({
        next: data => {
          console.log(data)
        },
        error: error => {
          console.error('There was an error!', error);
        }
      });
  }
}
