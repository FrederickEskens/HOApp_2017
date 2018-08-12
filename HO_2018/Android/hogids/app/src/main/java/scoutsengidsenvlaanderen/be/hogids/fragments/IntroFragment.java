package scoutsengidsenvlaanderen.be.hogids.fragments;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import scoutsengidsenvlaanderen.be.hogids.LocalStorage;
import scoutsengidsenvlaanderen.be.hogids.R;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link IntroFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class IntroFragment extends Fragment {
    private TextView lblIntroTitle;
    private TextView lblIntroSubTitle;
    private TextView lblIntroText;



    public IntroFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment.
     *
     * @return A new instance of fragment IntroFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static IntroFragment newInstance() {
        IntroFragment fragment = new IntroFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_intro, container, false);
        lblIntroTitle = view.findViewById(R.id.lblIntroTitle);
        lblIntroSubTitle = view.findViewById(R.id.lblintroSubtitle);
        lblIntroText = view.findViewById(R.id.lblIntroText);


        lblIntroTitle.setText(LocalStorage.getInstance().getCopy("Intro_Title"));
        lblIntroSubTitle.setText(LocalStorage.getInstance().getCopy("Intro_SubTitle"));
        lblIntroText.setText(LocalStorage.getInstance().getCopy("Intro_IntroText"));
        return view;

    }

}
