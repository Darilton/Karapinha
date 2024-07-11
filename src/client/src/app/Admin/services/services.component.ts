import { Component } from '@angular/core';
import { ServicesService } from '../../services/services.service';
import { NgFor } from '@angular/common';
import { Service } from '../../model/service.model';

@Component({
  selector: 'app-services',
  standalone: true,
  imports: [NgFor],
  templateUrl: './services.component.html',
  styleUrl: './services.component.scss'
})
export class ServicesComponent {
  Services: Service[] = [];
  constructor(private servicesService: ServicesService){}

  ngOnInit(): void {
    this.servicesService.updateServices()
      .subscribe(
        res => this.Services = res as Service[],
        err => console.log(err)
      );
  }
}
