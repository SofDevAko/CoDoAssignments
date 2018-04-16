import { Component, OnInit } from '@angular/core';
import { ShintoService } from '../shinto.service'
@Component({
  selector: 'app-mine',
  templateUrl: './mine.component.html',
  styleUrls: ['./mine.component.css']
})
export class MineComponent implements OnInit {
  svalue;
  samount;
  constructor(private _shintoService:ShintoService) { }

  ngOnInit() {
    this.getInfo();
  }
  getInfo(){
    var res = this._shintoService.getInfo();
    this.svalue = res.data.svalue;
    this.samount = res.data.samount;
  }
  mineCoin(){
    this._shintoService.mineCoin({'action':'mined','amount':1,'value':this.svalue});
    this.getInfo();
  }

}
