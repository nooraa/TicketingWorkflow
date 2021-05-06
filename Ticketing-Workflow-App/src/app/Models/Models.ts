export interface Category {
    id: number;
    name: string;
};

export interface SubCategory {
    id: number;
    name: string;
    categoryId: number;
};

export interface UserInfo {
    userId: number;
    username: string;
};

export interface TicketRequest {
    title: string;
    email: string;
    description: string;
    categoryId: number;
    subcategoryId: number;
};

export interface UnassignedTicket {
    id: number;
    title: string;
    submitterEmail: string;
    description: string;
    status: number;
};