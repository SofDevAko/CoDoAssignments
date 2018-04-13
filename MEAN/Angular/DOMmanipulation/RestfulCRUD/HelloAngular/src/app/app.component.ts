
import { HttpService } from './http.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // taskid ;
  newTask;
  edit;
  editTask;
  tasks = [];
  title = 'HelloAngular';
  constructor(private _httpService: HttpService){}
  
  ngOnInit(){
    // this.getTasksFromService();
    this.newTask = { title: "", description: "" };
    this.editTask = { title: "", description: "" };
    this.edit = false;
  }
  getTasksFromService(){
    let observable = this._httpService.getTasks();
    observable.subscribe(data => {
      console.log("Got our tasks!", data)
      // In this example, the array of tasks is assigned to the key 'tasks' in the data object.
      // This may be different for you, depending on how you set up your Task API.
      this.tasks = data['data'];
    });
  }
  createTask(){
    let observable = this._httpService.addTask(this.newTask);
    observable.subscribe(data => {
      console.log("Got data from post", data);
      this.newTask = { title: "", description: "" }
      this.getTasksFromService()
    })
  }
  showTask(id){
    this.edit = true;
    let observable = this._httpService.showTask(id);
    observable.subscribe(data => {
      console.log("Got single data from db", data);
      this.editTask = data["task"];
    })
  }
  updateTask(id){
    let observable = this._httpService.updateTask(this.editTask, id);
    observable.subscribe(data => {
      console.log("Got data from post", data);
      this.editTask = { title: "", description: "" }
      this.edit = false;
      this.getTasksFromService()
    })
  }
  deleteTask(id){
    let observable = this._httpService.deleteTask(id);
    observable.subscribe(data => {
      console.log("Deleted data from db", data);
    })
    this.getTasksFromService()
  }
  }


