
import { Category } from "src/app/models/Category";

export const ItemList = [
    {
        id: 1,
        name: 'Placa de Vídeo',
        price: 400,
        promotion: true,
        promotionValue: 150,
        ratingStars: 5,
        category: { id: 1, name: 'Informatica' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: true
    },
    {
        id: 2,
        name: 'Gabinete RedDragon',
        price: 1500,
        promotion: true,
        promotionValue: 800,
        ratingStars: 4,
        category: { id: 1, name: 'Informatica' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: true
    },
    {
        id: 3,
        name: 'Mouse Gamer RedDragon',
        price: 100,
        promotion: false,
        promotionValue: 99,
        ratingStars: 2,
        category: { id: 1, name: 'Informatica' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: true
    }, {
        id: 4,
        name: 'Cadeira Gamer',
        price: 2500,
        promotion: false,
        promotionValue: 800,
        ratingStars: 5,
        category: { id: 1, name: 'Informatica' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: true
    },
    {
        id: 5,
        name: 'Samsung S23',
        price: 5500,
        promotion: true,
        promotionValue: 4860,
        ratingStars: 5,
        category: { id: 2, name: 'Telefone' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: true
    },
    {
        id: 6,
        name: 'Iphone 13',
        price: 15000,
        promotion: true,
        promotionValue: 9860,
        ratingStars: 5,
        category: { id: 2, name: 'Telefone' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: true
    },
    {
        id: 7,
        name: 'Moto G90',
        price: 2100,
        promotion: false,
        promotionValue: 800,
        ratingStars: 3,
        category: { id: 2, name: 'Telefone' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: false
    }, {
        id: 8,
        name: 'Televisão 43" Com Alexa',
        price: 2999,
        promotion: true,
        promotionValue: 2499,
        ratingStars: 5,
        category: { id: 3, name: 'Eletronico' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: true
    },
    {
        id: 9,
        name: 'Smart Watch Samsung',
        price: 1500,
        promotion: true,
        promotionValue: 800,
        ratingStars: 4,
        category: { id: 2, name: 'Telefone' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: false
    },
    {
        id: 10,
        name: 'Fogão 4 bocas com tampa de vidro',
        price: 1500,
        promotion: true,
        promotionValue: 800,
        ratingStars: 4,
        category: { id: 3, name: 'Eletronico' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: true
    },
    {
        id: 11,
        name: 'Microondas',
        price: 550,
        promotion: false,
        promotionValue: 882.65,
        ratingStars: 3,
        category: { id: 3, name: 'Eletronico' } as Category, // Substitua 'Categoria 1' pelo nome desejado
        bestSeller: false
    }
];
