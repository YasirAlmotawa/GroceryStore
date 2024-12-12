"use client"
import { FlipWords } from '@/components/ui/FlipWords'
import Link from 'next/link'
import React, { useState } from 'react'
import { useRouter } from 'next/navigation'

const ProfilePage = () => {
  const router = useRouter();
  const[fullName, setFullName] = useState<string>("John Doe");
  const [email, setEmail] = useState<string>("john.doe@fakemail.com");
  const [username, setUsername] = useState<string>("doe123");
  const [address, setAddress] = useState<string>("1234 Sesame St");
  const [dateJoined, setDateJoined] = useState<string>("12/01/2024");
  const[number, setNumber] = useState<string>("123-456-7890");
  const [error, setError] = useState<string | null>(null);

  return (
    <div className='bg-zinc-950 text-zinc-100 p-5 w-[30rem] h-full flex flex-col rounded-xl'>
      <div className='flex flex-col items-center w-full'>
      <h1 className='absolute left-28'><Link href="/" className="text-purple-500 font-bold">Back to Shopping</Link></h1>
        <h1 className='mt-10 text-2xl font-bold mb-2'>Welcome<FlipWords words={["Loyal", "Valued", "Home" ]}/>Customer</h1>
      </div>
        <div className=' flex flex-col text-left px-6'>
          <div className=''>
          <span className='font-bold'>Full Name:</span><span className='ml-2'>{fullName}</span>
          </div>
          <div className=''>
          <span className='font-bold'>Date Joined:</span><span className='ml-2'>{dateJoined}</span>
          </div>
          <div>
          <span className='font-bold'>Email Address:</span><span className='ml-2'>{email}</span>
          </div>
          <div className=''>
          <span className='font-bold'>Phone Number:</span><span className='ml-2'>{number}</span>
          </div>
          <div className=''>
          <span className='font-bold'>Address:</span><span className='ml-2'>{address}</span>
          </div>
        </div>
    </div>
  )
}

export default ProfilePage