import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogActions, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'inform-dialog',
  templateUrl: './inform-dialog.component.html',
  standalone: true,
  imports: [MatDialogActions, MatDialogModule, MatButtonModule]
})
export class InformDialogComponent {}