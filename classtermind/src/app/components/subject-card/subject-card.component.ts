import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router'; 
import { SubjectDto } from 'app/models/subject-dto.model';

@Component({
  selector: 'app-subject-card',
  standalone: true,
  imports: [CommonModule, RouterModule], 
  templateUrl: './subject-card.component.html',
  styleUrls: ['./subject-card.component.css']
})
export class SubjectCardComponent {
  @Input() subject!: SubjectDto;
}
