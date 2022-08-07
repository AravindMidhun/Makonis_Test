import { Component, OnInit } from '@angular/core';
import { Person } from '../models/person';
import { PersonService } from '../_services/person.service';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {

  persons:Person[]=[];

  constructor(private personService:PersonService) {

   }

  ngOnInit(): void {
     this.loadPersons();
  }
loadPersons(){
  this.personService.getPersons().subscribe(
    {
      next:(response)=>{
        this.persons=response;
      },
      error:(e)=>{console.log(e)},
      complete:()=>{console.log('Completed')}
    }
  );
}

}
