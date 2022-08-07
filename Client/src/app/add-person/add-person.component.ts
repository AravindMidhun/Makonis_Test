import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Person } from '../models/person';
import { PersonService } from '../_services/person.service';
@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.css']
})
export class AddPersonComponent implements OnInit {
  model: Person = { firstName: "", lastName: "" };

  ngOnInit(): void {
  }

  constructor(private personService: PersonService, private router: Router) {

  }


  addPerson(form: NgForm) {
    // console.log(form);
    console.log(form.value["firstName"]);
    console.log(form.value["lastName"]);
    //form.value[]
    this.model.firstName = form.value["firstName"];
    this.model.lastName = form.value["lastName"];
    this.personService.addPerson(this.model).subscribe(
      {
        next: (response) => {
          this.router.navigate(['/'])
        },
        error: (e) => { console.log(e) },
        complete: () => console.log('Process Completed')
      }
    );
  }

  cancel() {
    this.router.navigate(['/'])
  }

}
