using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace App1
{
    public class MyScrollViewController : UIViewController
    {
        private readonly UIView content1;
        private readonly UIView content2;
        private readonly UIView content3;
        private readonly UIView containerView;
        private readonly UIScrollView scrollView;
        
        public MyScrollViewController()
        {
            content1 = new UIView();
            content2 = new UIView();
            content3 = new UIView();
            containerView = new UIView();
            scrollView = new UIScrollView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            content1.BackgroundColor = UIColor.Red;
            content2.BackgroundColor = UIColor.Green;
            content3.BackgroundColor = UIColor.Blue;

            containerView.BackgroundColor = UIColor.Yellow;
            containerView.AddSubviews(content1, content2, content3);
            containerView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            containerView.AddConstraints
                (
                    content1.WithSameTop(containerView).Plus(20),
                    content1.WithSameLeft(containerView).Plus(20),
                    content1.WithSameRight(containerView).Minus(20),
                    content1.Height().EqualTo(100),

                    content2.Below(content1).Plus(10),
                    content2.WithSameLeft(content1),
                    content2.WithSameRight(content1),
                    content2.WithRelativeHeight(content1, 2),

                    content3.Below(content2).Plus(10),
                    content3.WithSameLeft(content2),
                    content3.WithSameRight(content2),
                    content3.WithRelativeHeight(content1, 3),

                    //Magic Line 1
                    content3.WithSameBottom(containerView).Minus(20)
                );

            scrollView.BackgroundColor = UIColor.DarkGray;
            scrollView.AddSubview(containerView);
            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            scrollView.AddConstraints
                (
                    containerView.WithSameTop(scrollView),
                    containerView.WithSameLeft(scrollView),
                    containerView.WithSameRight(scrollView),
                    containerView.WithSameBottom(scrollView)
                );

            View.BackgroundColor = UIColor.White;
            View.AddSubviews(scrollView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints
                (
                    scrollView.WithSameTop(View).Plus(20),
                    scrollView.WithSameLeft(View).Plus(20),
                    scrollView.WithSameRight(View).Minus(20),
                    scrollView.WithSameBottom(View).Minus(20),

                    //Magic Line 2
                    containerView.WithSameWidth(scrollView)
                );
        }
    }
}