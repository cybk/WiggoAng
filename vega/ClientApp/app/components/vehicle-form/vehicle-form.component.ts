import { MakeService } from './../../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes:any;

  constructor(private makeService: MakeService) { }

  ngOnInit() {
    this.makeService.getMakex().subscribe(makes => {
      this.makes = makes;
      console.log("makes", this.makes);
    });
  }

}
