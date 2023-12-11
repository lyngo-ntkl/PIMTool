import { Employee } from "./employee";

export interface Group{
    id: number;
    version: number;
    groupLeader: Employee;
}