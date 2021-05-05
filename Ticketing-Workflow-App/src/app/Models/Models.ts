export interface Category {
    id: number;
    name: string;
};

export interface SubCategory {
    id: number;
    name: string;
    categoryId: number;
};

export interface TicketRequest {
    title: string;
    email: string;
    description: string;
    categoryId: number;
    subcategoryId: number;
};