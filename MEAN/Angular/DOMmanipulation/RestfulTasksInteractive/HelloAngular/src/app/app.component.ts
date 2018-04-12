
import { HttpService } from './http.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // taskid ;
  tasks = [];
  title = 'HelloAngular';
  constructor(private _httpService: HttpService){}
  
  ngOnInit(){
    // this.getTasksFromService();
  }
  getTasksFromService(){
    let observable = this._httpService.getTasks();
    observable.subscribe(data => {
      console.log("Got our tasks!", data)
      // In this example, the array of tasks is assigned to the key 'tasks' in the data object.
      // This may be different for you, depending on how you set up your Task API.
      this.tasks = data['data'];
      console.log(this.tasks)
    });
  }
  // getTaskById(e){
  //   e.preventDefault;
  //   console.log(e)
  //   let id;
  //   let observable = this._httpService.getTaskId(id);
  //   observable.subscribe(data => {
  //     this.taskid = data['data'];
  //     console.log(this.taskid)
  //   })
  }


