import Navbar from "../components/header/Navbar";
import Hero from "../components/hero/Hero";
import ProductCards from "@/components/products/ProductCards";
import Footer from "@/components/footer/Footer";


const Home = async () => {
  return (
    <main className="min-h-screen text-white">
      <Navbar />
      <Hero />

      <section id="store" className="p-28 flex flex-col gap-10">
        <ProductCards />
      </section>
      <Footer />
    </main>
  );
};

export default Home;
