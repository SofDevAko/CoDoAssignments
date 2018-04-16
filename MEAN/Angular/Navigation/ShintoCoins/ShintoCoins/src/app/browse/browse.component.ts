import { Component, OnInit } from '@angular/core';
import { ShintoService } from '../shinto.service'
@Component({
  selector: 'app-browse',
  templateUrl: './browse.component.html',
  styleUrls: ['./browse.component.css']
})
export class BrowseComponent implements OnInit {
  samount;
  svalue;
  res;
  constructor(private _shintoService:ShintoService) { }

  ngOnInit() {
    this.getInfo();
  }
  getInfo(){
    var res = this._shintoService.getInfo();
    this.svalue = res.data.svalue;
    this.samount = res.data.samount;
    this.res = res.data;
  }
}
