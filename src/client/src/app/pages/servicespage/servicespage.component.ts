import { Component } from '@angular/core';
import { Service } from '../../model/service.model';
import { NgFor, NgIf } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ServicesService } from '../../services/services.service';
import { Category } from '../../model/category.model';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-servicespage',
  standalone: true,
  imports: [NgIf, NgFor],
  templateUrl: './servicespage.component.html',
  styleUrl: './servicespage.component.scss'
})
export class ServicespageComponent {
  Services: Service[] = [];
  Categories: Category[] = [];

  constructor(private servicesService: ServicesService, private categoryService: CategoriesService){}

  ngOnInit(): void {
    this.getServices();
    this.categoryService.getCategories().subscribe(
      res => this.Categories = res as Category[],
      error => console.log("Could not load services")
    )
  }

  getServices(){
    this.servicesService.getServices().subscribe(
      {
        next: (res) => this.Services = res as Service[],
        error: (error) => alert("error")
      }
    )
  }
  getCategoryServices(categoryId: any){
    
    this.categoryService.getCategoryService(Number.parseInt(categoryId.value)).subscribe(
      {
        next: (res) => this.Services = res as Service[],
        error: (error) => alert("error")
      }
    );

  }

  cto(){
    alert();
  }
}
