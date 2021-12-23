import {Component} from '@angular/core';
import {DataService} from "../data.service";
import {Ingredient} from "../meal/ingredient";

@Component({
  selector: 'app-new-meal',
  templateUrl: './new-meal.component.html',
})
export class NewMealComponent {
  mealName: string;
  ingredients: Ingredient[] = [];
  ingredientsForMeal: Ingredient[] = [];

  constructor(private dataService: DataService) {
    dataService.getAllIngredients().subscribe(data => this.ingredients = data);
  }

  addIngredientForMeal(ingredient: Ingredient): void {
    this.ingredientsForMeal.push(ingredient);
  }

  addMeal() {
    this.dataService.addNewMeal(this.mealName, this.ingredientsForMeal);
    window.location.href = "/";
  }
}
