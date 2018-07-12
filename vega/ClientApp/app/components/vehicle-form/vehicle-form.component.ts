import { Component, OnInit } from '@angular/core';

import { FeatureService } from './../../services/feature.service';
import { MakeService } from './../../services/make.service';


@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  features: any[]= [];
  makes: any[] = [];
  models: any[] = [];
  vehicle: any = {};
  constructor(private makeService: MakeService, private featureService: FeatureService) { }

  ngOnInit() {
    this.makeService.getMakex().subscribe(makes =>  this.makes = makes);
    this.featureService.getFeatures().subscribe(feat => this.features = feat);
  }

  onMakeChange(){
    var selected = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selected ? selected.models: [];
  }
}
