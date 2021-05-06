import { Component, OnInit } from '@angular/core';
import { TicketManagmenetService } from '../../Services/ticket-Managment-Service';
import { UnassignedTicket, UserInfo } from '../../Models/Models';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-system-dashboard',
  templateUrl: './system-dashboard-component.html',
  styleUrls: ['./system-dashboard-component.scss']
})
export class SystemDashboardComponent implements OnInit {
  dashboardForm = new FormGroup({
    supUser: new FormControl('', [Validators.required]),
    checkbox: new FormControl('', [Validators.required]),
  });

  displayedColumns: string[] = ['tilte', 'description', 'submitterEmail', 'status', 'assign'];

  unassignedTickets: UnassignedTicket[] = [];
  supportUsers: UserInfo[] = [];
  selectedTickets: UnassignedTicket[] = [];
  dataSource = this.unassignedTickets;

  constructor(private ticketService: TicketManagmenetService) { 
  }

  ngOnInit(): void {
    this.getSupportUsers();
    this.getUnassignedTickets();

  }

  addTocCheckedList(element: UnassignedTicket) {
    if (this.selectedTickets !== null && !this.selectedTickets.find(i => i.id === element.id)) {
      this.selectedTickets.push(element);
    }
    console.log(this.selectedTickets);
  }

  updateCheckedList(element: UnassignedTicket) {
    if (this.selectedTickets !== null && !this.selectedTickets.find(i => i.id === element.id)) {
      this.selectedTickets.push(element);
    }
  }

  getOptionText(option: any) {
    if (option) return option.name;
  }

  onSubmit() {
    let userId = this.dashboardForm.controls['supUser'].value.id;
    if (this.selectedTickets !== null && this.selectedTickets.length !== 0) {
    this.ticketService.assignTickettoUser(userId, this.selectedTickets[0].id).subscribe(res => {
        console.log(res);
      });
        console.log(this.selectedTickets[0].id);
        console.log(userId);
    }

  }
  getUnassignedTickets(): void {
    this.ticketService.getUnassignedTickets().subscribe(
      (data) => {
        this.unassignedTickets = data;
        this.dataSource = this.unassignedTickets;
      }, err => {
        console.log(err);
      }
    )
  }
  getSupportUsers(): void {
    this.ticketService.GetSupportUsers()
      .subscribe(users => this.supportUsers = users);
  }
}
