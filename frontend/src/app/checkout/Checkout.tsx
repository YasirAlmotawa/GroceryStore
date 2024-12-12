"use client"
import { FlipWords } from "@/components/ui/FlipWords";
import Link from "next/link";
import React, { useState } from "react";

const CheckoutPage = () => {
  const[fullName, setFullName] = useState<string>("John Doe");
  const [email, setEmail] = useState<string>("john.doe@fakemail.com");
  const [number, setNumber] = useState<string>("123-456-7890)")
  const [address, setAddress] = useState<string>("1234 Sesame St");
  return (
    <form className="bg-zinc-950 text-zinc-100  p-5 w-[30rem] h-full flex flex-col rounded-xl">
      <div className="flex flex-col items-center w-full">
        <h1 className="absolute left-28">
          <Link href="/" className="text-purple-500 font-bold">
            Back to Shopping
          </Link>
        </h1>
        <h1 className="mt-10 text-2xl font-bold mb-2">
          Checkout
          <FlipWords words={["Fast", "Secure", "Easy"]} />
        </h1>
      </div>
      <div className="flex flex-col ml-6 ">
        <div className="">
          <span className="font-bold">Full Name: </span>
          <span className="">{fullName}</span>
        </div>
        <div>
          <span className="font-bold">Email Address: </span>
          <span className="">{email}</span>
        </div>
        <div className="">
          <span className="font-bold">Phone Number: </span>
          <span className="">{number}</span>
        </div>
        <div className=" mb-5">
          <span className="font-bold">Address: </span>
          <span className="">{address}</span>
        </div>
      </div>
      <div className=" flex flex-col">
        <div className=" mb-40">
          <span className="font-bold ml-6">Shopping Cart: </span>
          <span className=""></span>
        </div>
        <div className="">
          <span className="font-bold mb-3 ml-6">Item Count: </span>
          <span className=""></span>
        </div>
        <div className="mb-4">
          <span className="font-bold ml-6">Amount Due:</span>
          <span className=""></span>
        </div>
        <div className="ml-20">
          <input
            className="bg-zinc-950 outline mt-3 p-2 rounded-xl w-[12rem] mb-6"
            placeholder="Credit Card Number"
            type="numerical"
            maxLength={16}
            required
          />
        </div>
        <div className="ml-20">
          <input
            className="outline bg-zinc-950 p-2 rounded-xl w-[12rem] mb-5"
            placeholder="Security Code"
            type="password"
            maxLength={3}
            required
          />
        </div>
        <div className="flex justify-center ">
          <button className="rounded-3xl font-bold bg-purple-500 w-32 p-2">
            Pay
          </button>
        </div>
      </div>
    </form>
  );
};

export default CheckoutPage;
