import {Component} from '@angular/core';
import {DataService} from "../data.service";
import {Meal} from "../meal/meal";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  meals!: Meal[];

  constructor(private dataService: DataService) {
    dataService.showMenu().subscribe(data => this.meals = data);
  }
}
