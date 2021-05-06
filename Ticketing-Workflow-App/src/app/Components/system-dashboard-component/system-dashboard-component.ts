import { Component, OnInit } from '@angular/core';
import { TicketManagmenetService } from '../../Services/ticket-Managment-Service';
import { UserInfo, UnassignedTicket } from '../../Models/Models';

@Component({
  selector: 'app-system-dashboard',
  templateUrl: './system-dashboard-component.html',
  styleUrls: ['./system-dashboard-component.scss']
})
export class SystemDashboardComponent implements OnInit {
  displayedColumns: string[] = ['tilte', 'description', 'submitterEmail', 'status', 'assign'];
  unassignedTickets: UnassignedTicket[] = [];
  supportUsers: UserInfo[] = [];
  dataSource = this.unassignedTickets;
  constructor(private ticketService: TicketManagmenetService) { }

  ngOnInit(): void {
    this.getUnassignedTickets();
    this.getSupportUsers();
  }

  getUnassignedTickets(): void {
    this.ticketService.getUnassignedTickets().subscribe(
      (data) =>{ 
        this.unassignedTickets = data;
        this.dataSource = this.unassignedTickets;  
        console.log(this.unassignedTickets); 
      },err =>{
        console.log(err);
      }
    )}
  
  getSupportUsers():void {
    this.ticketService.GetSupportUsers().subscribe(
      (data) =>{ 
        this.supportUsers = data;
        console.log(this.supportUsers); 
      },err =>{
        console.log(err);
      }
    )}
}
