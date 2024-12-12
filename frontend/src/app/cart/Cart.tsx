"use client"
import { FlipWords } from "@/components/ui/FlipWords";
import Link from "next/link";
import { useState } from "react";

const CartPage = () => {
  const[itemCount, setItemCount] = useState<string>("5");
  const [amountDue, setAmountDue] = useState<string>("$15.27");
  const [shoppingCart, setShoppingCart] = useState<any>([]);

  return (
    <div className="bg-zinc-950 text-zinc-100 flex felx col items-center w-[30rem] rounded shadow-md">
      <div className="flex flex-col items-center w-full">
        <h1 className="absolute left-28">
          <Link href="/" className="text-purple-500 font-bold">
            Back to Shopping
          </Link>
        </h1>
        <h1 className="mt-10 text-2xl font-bold mb-2">
          Cart it
          <FlipWords words={["Quick", "Fresh", "Clean"]} />
        </h1>
        <div className=" flex flex-col mr-12">
          <div className="mb-80">
            <span className="font-bold">Shopping Cart: </span>
            <span className="ml-2"></span>
          </div>
          <div className="">
            <span className="font-bold mb-3">Item Count: {itemCount} </span>
            <span className=""></span>
          </div>
          <div className="mb-3">
            <span className="font-bold">Amount Due: {amountDue}</span>
            <span className=""></span>
          </div>
          <div>
            <a href="/checkout">
              <button className="ml-6 rounded-3xl font-bold bg-purple-500 w-32 p-2 mb-6">
                Checkout
              </button>
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CartPage;
