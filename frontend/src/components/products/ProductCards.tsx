import Cards from "./Cards";

const fetchProductCategoryById = async (id : number) => {
  const response = await fetch(`http://localhost:5058/api/product/category/${id}`);
  return response.json();
}

const ProductCards = async () => {
  const responseFreshProduce = await fetchProductCategoryById(1);
  const responseDairy = await fetchProductCategoryById(2);
  const responseDeli = await fetchProductCategoryById(3);

  const sections = [
    { title: "Fresh Produce", products: responseFreshProduce, id: 1 },
    { title: "Dairy", products: responseDairy, id: 2 },
    { title: "Deli", products: responseDeli, id: 3 },
  ];

  return (
    <>
      {sections.map((section) => (
        <div key={section.title}>
          <h1 className="text-4xl font-bold mb-10">{section.title}</h1>
          <div className="flex flex-row p-4 gap-10 overflow-x-scroll overscroll-x-auto scroll-smooth [scrollbar-width:none]">
            <Cards categoryId={section.id} />
          </div>               
        </div>
   
      ))}

    </>
  );
};

export default ProductCards;
