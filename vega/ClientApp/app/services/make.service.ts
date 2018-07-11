import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

export class MakeService {

  constructor(private http: Http) { }

  getMakex() {
    return this.http.get('/api/makes')
      .map(res => res.json());
  }
}
