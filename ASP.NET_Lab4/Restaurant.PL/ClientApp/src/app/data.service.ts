import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Meal} from "./meal/meal";


@Injectable()
export class DataService {

  constructor(private http: HttpClient) {
  }

  getAllMeals(): Observable<Meal[]> {
    return this.http.get<Meal[]>('/meal/get_meals');
  }

}
