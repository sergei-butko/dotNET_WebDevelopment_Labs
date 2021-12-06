import {Component} from '@angular/core';
import {DataService} from "../data.service";

@Component({
  selector: 'app-order',
  templateUrl: './meal.component.html',
})
export class MealComponent {

  constructor(private dataService: DataService) {
  }
}
